import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButcherStoreComponent } from './butcher-store.component';

describe('ButcherStoreComponent', () => {
  let component: ButcherStoreComponent;
  let fixture: ComponentFixture<ButcherStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ButcherStoreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ButcherStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
