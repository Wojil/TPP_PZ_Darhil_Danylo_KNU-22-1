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
        public List<Client> Clients{ get; set; } = null!;
        public List<Manager> Managers { get; set; } = null!;
        public List<OrderStatus> OrderStatuses { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public OrderPropertiesViewModel(List<Client> clients, List< Manager > managers, List<OrderStatus> orderStatuses, Order order)
        {
            this.Clients = clients;
            this.Managers = managers;
            this.OrderStatuses = orderStatuses;
            this.Order = order;
        }
        public OrderPropertiesViewModel()
        {
            Clients = new List<Client>();
            Managers = new List<Manager>();
            OrderStatuses = new List<OrderStatus>();
        }
    }
}
