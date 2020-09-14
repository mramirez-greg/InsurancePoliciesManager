import { Component, OnInit, TemplateRef } from '@angular/core';
import { faPlus, faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {
  CustomersListVm, InsurancePoliciesListVm, CustomerInsurancePolicyListVm, CustomerInsurancePolicyLookupDto,
  CustomersInsurancePoliciesClient, CustomerClient, InsurancePolicyClient, CreateCustomerInsurancePolicyCommand, UpdateCustomerInsurancePolicyCommand
} from '../gap-ipm-api';


@Component({
  selector: 'app-assign-policy',
  templateUrl: './assign-policy.component.html',
  styleUrls: ['./assign-policy.component.css']
})
export class AssignPolicyComponent implements OnInit {

  faPlus = faPlus;
  faEllipsisH = faEllipsisH;
  editAssignModalRef: BsModalRef;
  newAssignModalRef: BsModalRef;


  vm: CustomerInsurancePolicyListVm;
  customersListVm: CustomersListVm
  insurancePoliciesListVm: InsurancePoliciesListVm
  customerInsurancePolicy: CustomerInsurancePolicyLookupDto;
  newAssignEditor: any = {};
  editAssignEditor: any = {};


  constructor(private customersInsurancePoliciesClient: CustomersInsurancePoliciesClient, private customerClient: CustomerClient,
    private insuranceClient: InsurancePolicyClient,    private modalService: BsModalService) { }

  ngOnInit() {
    this.getCustomersInsurancePolicies();
    this.getCustomers();
    this.getInsurancePolicies();
  }

  getCustomers(): void {
    this.customerClient.get().subscribe(
      result => {
        this.customersListVm = result;
      },
      error => console.error(error)
    );
  }
  getInsurancePolicies(): void {
    this.insuranceClient.get().subscribe(
      result => {
        this.insurancePoliciesListVm = result;
      },
      error => console.error(error)
    );
  }
  getCustomersInsurancePolicies(): void {
    this.customersInsurancePoliciesClient.get().subscribe(
      result => {
        this.vm = result;
      },
      error => console.error(error)
    );
  }
  addAssign(): void {
    
    this.customersInsurancePoliciesClient.create(CreateCustomerInsurancePolicyCommand.fromJS(this.newAssignEditor)).subscribe(
      result => {
        if (result> 0) {
          this.getCustomersInsurancePolicies();
          this.newAssignCancelled();
        }
      },
      error => {
        let errors = JSON.parse(error.response);
      }
    )
  }
  updateAssign(): void {
    this.customersInsurancePoliciesClient.update(this.customerInsurancePolicy.customerInsurancePolicyId, UpdateCustomerInsurancePolicyCommand.fromJS(this.editAssignEditor)).subscribe(
      () => {
       
        this.getCustomersInsurancePolicies();
        this.editAssignModalRef.hide();
        this.newAssignEditor = {};
       
      },
      error => {
        let errors = JSON.parse(error.response);
      }
    )
  }
  showAssignEditModal(template: TemplateRef<any>, item: CustomerInsurancePolicyLookupDto): void {
    
    this.customerInsurancePolicy = item;
    this.editAssignEditor = {
      ...this.customerInsurancePolicy
    };
    this.editAssignModalRef = this.modalService.show(template);
  }
  showNewAssignModal(template: TemplateRef<any>): void {
    this.newAssignModalRef = this.modalService.show(template);
  }
  newAssignCancelled(): void {
    this.newAssignModalRef.hide();
    this.newAssignEditor = {};
  }

}
