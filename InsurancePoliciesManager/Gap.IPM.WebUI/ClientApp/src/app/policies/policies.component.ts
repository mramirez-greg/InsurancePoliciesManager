import { Component, OnInit, TemplateRef } from '@angular/core';
import { InsurancePoliciesListVm, InsurancePolicyClient, InsurancePolicyLookupDto, CoverageTypesListVm, CoverageTypeClient, UpdateInsurancePolicyCommand, CreateInsurancePolicyCommand } from '../gap-ipm-api';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { faEllipsisH, faPlus } from '@fortawesome/free-solid-svg-icons';



@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styleUrls: ['./policies.component.css']
})
export class PoliciesComponent implements OnInit {

  vm: InsurancePoliciesListVm;
insurancePolicy: InsurancePolicyLookupDto;
  coverageTypeVm: CoverageTypesListVm;

  faPlus = faPlus;
  faEllipsisH = faEllipsisH;
  editPolicyModalRef: BsModalRef;
  newPolicyModalRef: BsModalRef;
  deleteListModalRef: BsModalRef;
  errormod: string;

  newPolicyEditor: any = {};
  editPolicyEditor: any = {};

  constructor(private insuranceClient: InsurancePolicyClient, private coverageTypeClient: CoverageTypeClient,private modalService: BsModalService) {
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
   
    this.insuranceClient.create(<CreateInsurancePolicyCommand>{
      name: this.newPolicyEditor.name,
      description: this.newPolicyEditor.description,
      coverageTypeId: this.newPolicyEditor.coverageTypeId,
      coverage: this.newPolicyEditor.coverage,
      coverageStart: this.newPolicyEditor.coverageStart,
      coveragePeriod: this.newPolicyEditor.coveragePeriod,
      policyValue: this.newPolicyEditor.policyValue,
      riskType: this.newPolicyEditor.riskType
    }).subscribe(
      result => {
        if (result> 0) {
          this.getInsurancePolicies();
          this.newPolicyModalRef.hide();
          this.newPolicyEditor = {}
        }
      },
      error => {
        let errors = JSON.parse(error.response);
        this.errormod = errors.errors.Coverage[0];
        setTimeout(() => document.getElementById("firstName").focus(), 250);
      }
    )
  }
  updatePolicy(): void {
    
    this.insuranceClient.update(this.insurancePolicy.insurancePolicyId, <UpdateInsurancePolicyCommand>{
      insurancePolicyId: this.insurancePolicy.insurancePolicyId,
      name: this.editPolicyEditor.name,
      description: this.editPolicyEditor.description,
      coverageTypeId: this.editPolicyEditor.coverageTypeId,
      coverage: this.editPolicyEditor.coverage,
      coverageStart: this.editPolicyEditor.coverageStart,
      coveragePeriod: this.editPolicyEditor.coveragePeriod,
      policyValue: this.editPolicyEditor.policyValue,
      riskType: this.editPolicyEditor.riskType
    })
      .subscribe(
        () => {
          this.getInsurancePolicies();
          this.editPolicyEditor = {};
          this.editPolicyModalRef.hide();
        },
        error => {
          let errors = JSON.parse(error.response);
          this.errormod = errors.errors.Coverage[0];
          
         
        } 
      );
  }
  showNewPolicyModal(template: TemplateRef<any>): void {
    this.errormod = "";
    this.newPolicyModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById("name").focus(), 250);
  }
  showPolicyEditModal(template: TemplateRef<any>, item: InsurancePolicyLookupDto): void {
    this.errormod = "";
    this.insurancePolicy = item;
    this.editPolicyEditor = {
      ...this.insurancePolicy
    };
    this.editPolicyModalRef = this.modalService.show(template);
  }
  confirmDeleteList(template: TemplateRef<any>) {
    this.editPolicyModalRef.hide();
    this.deleteListModalRef = this.modalService.show(template);
  }
  newPolicyCancelled(): void {
    this.newPolicyModalRef.hide();
    this.newPolicyEditor = {};
  }
  deletePolicy(): void {
    this.insuranceClient.delete(this.insurancePolicy.insurancePolicyId)
      .subscribe(
        () => {
          this.getInsurancePolicies();
          this.deleteListModalRef.hide();
        },
        error => console.error(error)
      );
  }


}
