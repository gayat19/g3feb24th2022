import { Injectable } from '@angular/core';
import { Customer } from '../models/customer';


export class CustomerService {
  customers:Customer[]
  constructor() { 
    this.customers = [
      new Customer(101,"Ramu","assets/images/Pic1.jfif"),
      new Customer(102,"Somu","assets/images/Pic2.jfif")
    ]
  }
  getCustomers(){
    return this.customers;
  }
}
