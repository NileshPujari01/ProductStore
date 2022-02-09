import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminUserLandingPageComponent } from './admin-user-landing-page.component';

describe('AdminUserLandingPageComponent', () => {
  let component: AdminUserLandingPageComponent;
  let fixture: ComponentFixture<AdminUserLandingPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminUserLandingPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminUserLandingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
