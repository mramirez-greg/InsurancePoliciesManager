import { Component, OnInit, TemplateRef } from '@angular/core';
import { faPlus, faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';


import {
  CustomersListVm, CustomersLookupDto, CustomerClient, CreateCustomerCommand, UpdateCustomerCommand
} from '../gap-ipm-api';


@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  faPlus = faPlus;
  faEllipsisH = faEllipsisH;
  editCustomerModalRef: BsModalRef;
  newCustomerModalRef: BsModalRef;

  vm: CustomersListVm;
  customer: CustomersLookupDto;

  newCustomerEditor: any = {};
  editCustomerEditor: any = {};

  constructor(private customerClient: CustomerClient, private modalService: BsModalService) {
   
  }

  ngOnInit() {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerClient.get().subscribe(
      result => {
        this.vm = result;
      },
      error => console.error(error)
    );
  }
  addCustomer(): void {
    this.customerClient.create(CreateCustomerCommand.fromJS(this.newCustomerEditor)).subscribe(
      result => {
        if (result.trim().length>0) {
          this.getCustomers();
          this.newCustomerModalRef.hide();
        }
      },
      error => {
        let errors = JSON.parse(error.response);

        if (errors && errors.Title) {
          this.newCustomerEditor.error = errors.Title[0];
        }

        setTimeout(() => document.getElementById("firstName").focus(), 250);
      }
    )
  }
  updateCustomer(): void {
    this.customerClient.update(this.customer.customerId, UpdateCustomerCommand.fromJS(this.editCustomerEditor))
      .subscribe(
        () => {
          this.getCustomers();
          this.editCustomerEditor = {};
          this.editCustomerModalRef.hide();
        },
        error => console.error(error)
      );
  }

  showCustomerEditModal(template: TemplateRef<any>,item: CustomersLookupDto): void {
    this.customer = item;
    this.editCustomerEditor = {
      ...this.customer
    };
    this.editCustomerModalRef = this.modalService.show(template);
  }
  showNewCustomerModal(template: TemplateRef<any>): void {
    this.newCustomerModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById("customerId").focus(), 250);
  }
  newCustomerCancelled(): void {
    this.newCustomerModalRef.hide();
    this.newCustomerEditor = {};
  }
}
