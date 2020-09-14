import { Component, OnInit, TemplateRef } from '@angular/core';
import { faPlus, faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';


import {
  InsurancePoliciesListVm, InsurancePolicyLookupDto, InsurancePolicyClient,
  CoverageTypesListVm, CoverageTypeLookupDto, CoverageTypeClient,
  CreateInsurancePolicyCommand, UpdateInsurancePolicyCommand
} from '../gap-ipm-api';


@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styleUrls: ['./policies.component.css']
})
export class PoliciesComponent implements OnInit {

  faPlus = faPlus;
  faEllipsisH = faEllipsisH;
  editPolicyModalRef: BsModalRef;
  newPolicyModalRef: BsModalRef;
  deleteListModalRef: BsModalRef;

  vm : InsurancePoliciesListVm;
  insurancePolicy: InsurancePolicyLookupDto;
  coverageTypeVm: CoverageTypesListVm;
  coverageTypeDto: CoverageTypeLookupDto;
  

  newPolicyEditor: any = {};
  editPolicyEditor: any = {};

  constructor(private insuranceClient: InsurancePolicyClient, private coverageTypeClient: CoverageTypeClient, private modalService: BsModalService) {
    coverageTypeClient.get().subscribe(
      result => {
        this.coverageTypeVm = result;
      },
      error => console.error(error)
    );
    

  }

  ngOnInit() {
    this.getInsurancePolicies();
  }

  getInsurancePolicies(): void {
    this.insuranceClient.get().subscribe(
      result => {
        this.vm = result;
      },
      error => console.error(error)
    );
  }
  addPolicy(): void {
    this.insuranceClient.create(CreateInsurancePolicyCommand.fromJS(this.newPolicyEditor)).subscribe(
      result => {
        if (result > 0) {
          this.getInsurancePolicies();
          this.newPolicyEditor.hide();
        }
      },
      error => {
        let errors = JSON.parse(error.response);

        if (errors && errors.Title) {
          this.newPolicyEditor.error = errors.Title[0];
        }

        setTimeout(() => document.getElementById("name").focus(), 250);
      }
    )    
  }
  updatePolicy(): void {
    this.editPolicyEditor.insurancePolicyId = this.insurancePolicy.id
    this.insuranceClient.update(this.insurancePolicy.id, UpdateInsurancePolicyCommand.fromJS(this.editPolicyEditor))
      .subscribe(
        () => {
          this.getInsurancePolicies();
          this.editPolicyModalRef.hide();
        },
        error => console.error(error)
      );
  }
  deletePolicy(): void {
    this.insuranceClient.delete(this.insurancePolicy.id)
      .subscribe(
        () => {
          this.getInsurancePolicies();
          this.deleteListModalRef.hide();
        },
        error => console.error(error)
      );
  }
  confirmDeleteList(template: TemplateRef<any>) {
    this.editPolicyModalRef.hide();
    this.deleteListModalRef = this.modalService.show(template);
  }

  showPolicyEditModal(template: TemplateRef<any>, item: InsurancePolicyLookupDto): void {
    this.insurancePolicy = item;
    this.editPolicyEditor = {
      ...this.insurancePolicy
    };
    this.editPolicyModalRef = this.modalService.show(template);
  }
  showNewPolicyModal(template: TemplateRef<any>): void {
    this.newPolicyModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById("name").focus(), 250);
  }
  newPolicyCancelled(): void {
    this.newPolicyModalRef.hide();
    this.newPolicyEditor = {};
  }

}
