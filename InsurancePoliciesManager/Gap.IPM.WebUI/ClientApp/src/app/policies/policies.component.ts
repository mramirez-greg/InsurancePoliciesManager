import { Component, OnInit, TemplateRef } from '@angular/core';
import { faPlus, faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styleUrls: ['./policies.component.css']
})
export class PoliciesComponent implements OnInit {

  faPlus = faPlus;
  faEllipsisH = faEllipsisH;
  policyDetailsModalRef: BsModalRef;
  constructor(private modalService: BsModalService) { }

  ngOnInit() {
  }

  showPolicyDetailsModal(template: TemplateRef<any>): void {
   

    this.policyDetailsModalRef = this.modalService.show(template);
  }

}
