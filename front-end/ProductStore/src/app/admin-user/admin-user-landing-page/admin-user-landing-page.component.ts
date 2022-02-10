import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-user-landing-page',
  templateUrl: './admin-user-landing-page.component.html',
  styleUrls: ['./admin-user-landing-page.component.scss']
})
export class AdminUserLandingPageComponent implements OnInit {
@Input() userTypeVal: string = "AdminUser";
  constructor() { }

  ngOnInit(): void {
  }

}
