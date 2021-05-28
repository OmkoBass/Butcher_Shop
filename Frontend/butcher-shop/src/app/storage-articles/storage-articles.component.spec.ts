import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StorageArticlesComponent } from './storage-articles.component';

describe('StorageArticlesComponent', () => {
  let component: StorageArticlesComponent;
  let fixture: ComponentFixture<StorageArticlesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StorageArticlesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StorageArticlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
