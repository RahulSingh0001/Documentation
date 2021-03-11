import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeropipeComponent } from './heropipe.component';

describe('HeropipeComponent', () => {
  let component: HeropipeComponent;
  let fixture: ComponentFixture<HeropipeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeropipeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeropipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
