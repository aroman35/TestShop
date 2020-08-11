using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;

namespace TestShop.Application.Infrastructure.Migration
{
    public class MigrateDataBaseHandler : IRequestHandler<MigrateDataBaseCommand>
    {
        private readonly ITestShopDbContext _testShopDbContext;
        private readonly ILogger<MigrateDataBaseHandler> _logger;

        public MigrateDataBaseHandler(ITestShopDbContext testShopDbContext, ILogger<MigrateDataBaseHandler> logger)
        {
            _testShopDbContext = testShopDbContext;
            _logger = logger;
        }

        public async Task<Unit> Handle(MigrateDataBaseCommand request, CancellationToken cancellationToken)
        {
            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(10));

            var migrationResult = await retryPolicy
                .ExecuteAndCaptureAsync(() => _testShopDbContext.Database.MigrateAsync(cancellationToken: cancellationToken));

            if (migrationResult.FinalException == null) return Unit.Value;

            _logger.LogError($"Unable to configure database: {migrationResult.FinalException.Message}");
            throw migrationResult.FinalException;
        }
    }
}