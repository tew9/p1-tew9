using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Store: AComponents
    {
        public string location { get; set; }
        #region Navigational Properties
        public List<PizzaStore> PizzaStore { get; set; }
        public string Manager { get; set; } 
        #endregion
        public Store(){}
    }
}