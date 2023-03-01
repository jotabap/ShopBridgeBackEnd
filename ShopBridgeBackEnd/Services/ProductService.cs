using ShopBridge.Entities.Entities;
using ShopBridge.Models.ResponseModel;
using ShopBridge.Utilities.CommonDecoration;
using ShopBridge.Utilities.Repositories;

namespace ShopBridgeBackEnd.Services
{
    [Service]
    public class ProductService
    {
        private readonly IRepository<Item> _ItemRepository;

        public ProductService(IRepository<Item> itemRepository)
        {
            _ItemRepository = itemRepository;
        }

        public async Task<object> Get(int skip, int take)
        {
            var apiResponse = new GenericResponse();

            try
            {
                var GetItem = _ItemRepository.Get();
                
                if (!GetItem.Any())
                {
                    apiResponse.OperationSucces = false;
                    apiResponse.ErrorMessage = "There is no Product! ";
                    return apiResponse;
                }
                var count = GetItem?.Skip((skip - 1) * take)?.Take(take).Count();
                var total = GetItem?.Count();
                apiResponse.ObjectResponse = GetItem?.Skip((skip - 1) * take)?.Take(take);                
                apiResponse.TotalRecords = (long)total;
                apiResponse.CountRecords = (long)count;
                apiResponse.OperationSucces = true;

            }
            catch (Exception e)
            {
                apiResponse.ErrorMessage = $"{e.Message ?? string.Empty}";
                apiResponse.OperationSucces = false;
            }
            return apiResponse;
        }
    }
}
