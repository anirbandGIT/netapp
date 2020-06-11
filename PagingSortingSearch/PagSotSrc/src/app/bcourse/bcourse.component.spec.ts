import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BcourseComponent } from './bcourse.component';

describe('BcourseComponent', () => {
  let component: BcourseComponent;
  let fixture: ComponentFixture<BcourseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BcourseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BcourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
