using DeliVeggie.Models.Entity.Request;
using DeliVeggie.Models.Entity.Response;
using DeliVeggie.Product.Service.Abstract;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using DeliVeggie.MongoDB.Abstract;
using DeliVeggie.MongoDB.Mdo;

namespace DeliVeggie.Product.Service.Implementation
{
    public class ProductResponseService : IProductResponseService
    {
        public readonly IBus _bus;
        private readonly IProductRepository _productRepository;
        private readonly IPriceReductionRepository _priceReductionRepository;

        public ProductResponseService(IProductRepository productRepository, IPriceReductionRepository priceReductionRepository)
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
            _productRepository = productRepository;
            _priceReductionRepository = priceReductionRepository;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Product Microservice Started..");

            try
            {
                var getDetailsTask = HandleGetProductDetailsRequestAsync(cancellationToken);
                var getAllTask = HandleGetAllProductRequestAsync(cancellationToken);

                return Task.WhenAll(getDetailsTask, getAllTask);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Stops the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("ProductMessageBus Stopping.");
            return Task.CompletedTask;
        }
        #region PRIVATE METHODS
        private Task HandleGetProductDetailsRequestAsync(CancellationToken cancellationToken)
        {
            return this._bus
                          .Rpc
                          .RespondAsync<ProductDetailsRequestData, ProductDetailsResponseData>(async request =>
                          {
                              try
                              {
                                  var reduction = 0.0;
                                  var productMdo = await _productRepository.GetProductByIdAsync(request.Id);
                                  var priceReductionMdo = await _priceReductionRepository.GetPriceReductionAsync(request.DayOfWeek);
                                  if (priceReductionMdo != null)
                                      reduction = priceReductionMdo.Reduction;
                                  if (productMdo != null)
                                  {
                                      return this.MapDtoToResponseData(productMdo, reduction);
                                  }
                              }
                              catch (Exception ex)
                              {
                                  Console.WriteLine(ex.Message, $"Error when getting product: {request?.Id}");
                              }
                              return new ProductDetailsResponseData();
                          }, cancellationToken);
        }

        private Task HandleGetAllProductRequestAsync(CancellationToken cancellationToken)
        {
            return this._bus
                          .Rpc
                          .RespondAsync<ProductListRequestData, ProductListResponseData>(async request =>
                          {
                              try
                              {
                                  var productDtos = await _productRepository.GetAllAsync();
                                  
                                  if (productDtos?.Count() > 0)
                                  {
                                      return this.MapDtoToResponseData(productDtos);
                                  }
                              }
                              catch (Exception ex)
                              {
                                  Console.WriteLine(ex.Message, $"Error when getting products");
                              }

                              return new ProductListResponseData ();

                          }, cancellationToken);
        }

        private ProductDetailsResponseData MapDtoToResponseData(ProductMdo product, double priceReduction)
        {
            return new ProductDetailsResponseData
            {
                EntryDate = product.EntryDate,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price - priceReduction
            };
        }

        private ProductListResponseData MapDtoToResponseData(IEnumerable<ProductMdo> products)
        {
            return new ProductListResponseData
            {
                Products = products
                            .Select(x => this.MapDtoToResponseData(x))
                            .ToList()
            };
        }
        private ProductDetailsResponseData MapDtoToResponseData(ProductMdo product)
        {
            return new ProductDetailsResponseData
            {
                Id = product.Id,
                Name = product.Name
            };
        }
        #endregion
    }
}
