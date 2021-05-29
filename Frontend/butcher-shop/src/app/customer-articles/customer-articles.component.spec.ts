import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerArticlesComponent } from './customer-articles.component';

describe('CustomerArticlesComponent', () => {
  let component: CustomerArticlesComponent;
  let fixture: ComponentFixture<CustomerArticlesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerArticlesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerArticlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
