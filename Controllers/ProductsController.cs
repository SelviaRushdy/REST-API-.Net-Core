using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using REST_API_.Net_Core.Entities;
using REST_API_.Net_Core.Models;
using REST_API_.Net_Core.Services;
using System.Collections.Generic;
using System.Xml.XPath;

namespace REST_API_.Net_Core.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductsRepository productsRepository,
            IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        [HttpGet()]
        public ResponseModel<List<ProductsDto>> GetProducts()
        {
            var ResponseModel = new ResponseModel<List<ProductsDto>>();

            try
            {
                var result = productsRepository.GetAllProducts();
                ResponseModel.Success = true;
                ResponseModel.Result = mapper.Map<List<ProductsDto>>(result);
                ResponseModel.Message = "Success";

                return ResponseModel;
            }
            catch (Exception ex)
            {
                ResponseModel.Success = false;
                ResponseModel.Message = ex.Message;
                return ResponseModel;
            }
        }

        [HttpGet("{productId}")]
        public ResponseModel<ProductsDto> GetProductByID(Guid productId)
        {
            var ResponseModel = new ResponseModel<ProductsDto>();
            try
            {
                var result = productsRepository.GetProductByID(productId);
                ResponseModel.Success = true;

                if (result == null)
                {
                    ResponseModel.Message = "Not Found";
                    return ResponseModel;
                }
                ResponseModel.Result = mapper.Map<ProductsDto>(result);
                ResponseModel.Message = "Success";

                return ResponseModel;
            }
            catch (Exception ex)
            {
                ResponseModel.Success = false;
                ResponseModel.Message = ex.Message;
                return ResponseModel;
            }
        }

        [HttpGet("{categoryId}/Products")]
        public ResponseModel<List<ProductsDto>> GetProductsByCategoryId(Guid categoryId)
        {
            var ResponseModel = new ResponseModel<List<ProductsDto>>();
            try
            {
                ResponseModel.Success = true;
                if (!productsRepository.ProductExists(categoryId))
                {
                    ResponseModel.Message = "Category Not found";
                    return ResponseModel;
                }

                var result = productsRepository.GetProductsByCategoryID(categoryId);
                if (result == null)
                {
                    ResponseModel.Message = "No products found for this Category";
                    return ResponseModel;
                }
                ResponseModel.Result = mapper.Map<List<ProductsDto>>(result);
                ResponseModel.Message = "Success";

                return ResponseModel;
            }
            catch (Exception ex)
            {
                ResponseModel.Success = false;
                ResponseModel.Message = ex.Message;
                return ResponseModel;
            }
        }

        [HttpPost]
        public ResponseModel<ProductsDto> CreateProduct(ProductsDto product)
        {
            var ResponseModel = new ResponseModel<ProductsDto>();
            try
            {
                ResponseModel.Success = true;
                if (!productsRepository.ProductExists(product.CateogryID))
                {
                    ResponseModel.Message = "Category Not found, please select another";
                    return ResponseModel;
                }
                var productEntity = mapper.Map<Products>(product);
                productsRepository.AddProduct(productEntity);
                productsRepository.Save();
                ResponseModel.Result = mapper.Map<ProductsDto>(productEntity);
                ResponseModel.Message = "Product added successfully";

                return ResponseModel;
            }
            catch (Exception ex)
            {
                ResponseModel.Success = false;
                ResponseModel.Message = ex.Message;
                return ResponseModel;
            }
        }

        [HttpPut("{productId}")]
        public ResponseModel<ProductDtoForUpdate> UpdateProductByID(ProductDtoForUpdate product,Guid productId)
        {
            var ResponseModel = new ResponseModel<ProductDtoForUpdate>();
            try
            {
                var result = productsRepository.GetProductByID(productId);
                ResponseModel.Success = true;

                if (result == null)
                {
                    ResponseModel.Message = "Not Found";
                    return ResponseModel;
                }
                if (!productsRepository.ProductExists(product.CateogryID))
                {
                    ResponseModel.Message = "Category Not found";
                    return ResponseModel;
                }
                var id= result.ID;
                var model= mapper.Map(product, result);
                model.ID = id;
                productsRepository.UpdateProduct(model);
                ResponseModel.Result = mapper.Map<ProductDtoForUpdate>(model);
                ResponseModel.Message = "Product updated successfully";
                return ResponseModel;
            }
            catch (Exception ex)
            {
                ResponseModel.Success = false;
                ResponseModel.Message = ex.Message;
                return ResponseModel;
            }
        }

        [HttpPatch("{productId}")]
        public ResponseModel<ProductDtoForUpdate> PartiallyUpdateProduct(JsonPatchDocument<ProductDtoForUpdate> product, Guid productId)
        {
            var ResponseModel = new ResponseModel<ProductDtoForUpdate>();
            try
            {
                var result = productsRepository.GetProductByID(productId);
                ResponseModel.Success = true;

                if (result == null)
                {
                    ResponseModel.Message = "Not Found";
                    return ResponseModel;
                }
                var resultMapped = mapper.Map<ProductDtoForUpdate>(result);
                product.ApplyTo(resultMapped);
                if (!productsRepository.ProductExists(resultMapped.CateogryID))
                {
                    ResponseModel.Message = "Category Not found";
                    return ResponseModel;
                }
                var model = mapper.Map(resultMapped, result);
                productsRepository.UpdateProduct(model);
                ResponseModel.Result = mapper.Map<ProductDtoForUpdate>(model);
                ResponseModel.Message = "Product updated successfully";
                return ResponseModel;
            }
            catch (Exception ex)
            {
                ResponseModel.Success = false;
                ResponseModel.Message = ex.Message;
                return ResponseModel;
            }

        }

        [HttpDelete("{productId}")]
        public ResponseModel<ProductsDto> DeleteProductByID(Guid productId)
        {
            var ResponseModel = new ResponseModel<ProductsDto>();
            try
            {
                var result = productsRepository.GetProductByID(productId);
                ResponseModel.Success = true;
                if (result == null)
                {
                    ResponseModel.Message = "Not Found";
                    return ResponseModel;
                }
                var productEntity = mapper.Map<Products>(result);
                productsRepository.DeleteProduct(productEntity);
                ResponseModel.Message = "Product Deleted successfully";
                return ResponseModel;
            }
            catch (Exception ex)
            {
                ResponseModel.Success = false;
                ResponseModel.Message = ex.Message;
                return ResponseModel;
            }
        }

    }
}
