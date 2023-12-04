using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;

namespace TPP_PZ_Darhil_Danylo.DAL.ViewModels
{
    public class OrderPropertiesViewModel
    {
        public List<Client> clients{ get; set; } = null!;
        public List<Manager> managers { get; set; } = null!;
        public List<OrderStatus> orderStatuses { get; set; } = null!;
        public Order order { get; set; } = null!;
        public OrderPropertiesViewModel(List<Client> clients, List< Manager > managers, List<OrderStatus> orderStatuses, Order order)
        {
            this.clients = clients;
            this.managers = managers;
            this.orderStatuses = orderStatuses;
            this.order = order;
        }
        public OrderPropertiesViewModel()
        {
            clients = new List<Client>();
            managers = new List<Manager>();
            orderStatuses = new List<OrderStatus>();
        }
    }
}
