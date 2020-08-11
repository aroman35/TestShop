namespace TestShop.WebApi.Models.ResponseModels.Abstractions
{
    public class ResponseModel<TResponseData>
    {
        public ResponseModel(TResponseData payload)
        {
            Payload = payload;
        }
        public TResponseData Payload { get; }
    }
}