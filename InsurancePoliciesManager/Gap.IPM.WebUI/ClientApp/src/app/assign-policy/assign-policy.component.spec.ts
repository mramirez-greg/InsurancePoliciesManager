import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignPolicyComponent } from './assign-policy.component';

describe('AssignPolicyComponent', () => {
  let component: AssignPolicyComponent;
  let fixture: ComponentFixture<AssignPolicyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssignPolicyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignPolicyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
