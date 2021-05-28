import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditStorageDialogComponent } from './edit-storage-dialog.component';

describe('EditStorageDialogComponent', () => {
  let component: EditStorageDialogComponent;
  let fixture: ComponentFixture<EditStorageDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditStorageDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditStorageDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
