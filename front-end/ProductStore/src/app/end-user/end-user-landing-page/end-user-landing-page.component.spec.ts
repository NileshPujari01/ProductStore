import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EndUserLandingPageComponent } from './end-user-landing-page.component';

describe('EndUserLandingPageComponent', () => {
  let component: EndUserLandingPageComponent;
  let fixture: ComponentFixture<EndUserLandingPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EndUserLandingPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EndUserLandingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
