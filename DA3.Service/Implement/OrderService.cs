using AutoMapper;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.Extensions.Logging;

namespace DA3.Service.Implement
{
    public class OrderService : IOrderService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public OrderService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Order> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<OrderModel> AllOrders()
        {
            try
            {
                var entitys = _dbContext.Orders.ToList() ?? new List<Order>();
                var models = _mapper.Map<List<Order>, List<OrderModel>>(entitys);

                return models;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Create(OrderModel orderModel)
        {
            try
            {
                var entity = _mapper.Map<OrderModel, Order>(orderModel);
                _dbContext.Orders.AddAsync(entity);
                _dbContext.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string CreateOrderDetail(OrderDetailModel orderDetailModel)
        {
            try
            {
                var entity = _mapper.Map<OrderDetailModel, OrderDetails>(orderDetailModel);
                _dbContext.OrderDetails.AddAsync(entity);
                _dbContext.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public OrderModel GetByUserId(string userId)
        {
            try
            {
                var orderEntity = _dbContext.Orders.Where(x => x.UserId == userId).FirstOrDefault() ?? new Order();
                var orderDetails =_dbContext.OrderDetails.Where(x => x.OrderId == orderEntity.Id.ToString()).ToList();
                orderEntity.OrderDetails = orderDetails;

                var order = _mapper.Map<Order, OrderModel>(orderEntity);

                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
