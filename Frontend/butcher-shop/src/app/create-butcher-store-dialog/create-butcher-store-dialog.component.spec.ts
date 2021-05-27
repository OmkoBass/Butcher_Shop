import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateButcherStoreDialogComponent } from './create-butcher-store-dialog.component';

describe('CreateButcherStoreDialogComponent', () => {
  let component: CreateButcherStoreDialogComponent;
  let fixture: ComponentFixture<CreateButcherStoreDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateButcherStoreDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateButcherStoreDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
