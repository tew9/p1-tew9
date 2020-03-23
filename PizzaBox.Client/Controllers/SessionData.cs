using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PizzaBox.Client.Models
{
  public class SessionData
  {
    //Display Properties
    static readonly PizzaRepository _ps =  new PizzaRepository();
    public static long userId { get; set; }
  }
}