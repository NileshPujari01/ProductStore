import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent implements OnInit {
  public adminUser = "AdminUser";
  public endUser = "EndUser";
  isShown: boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

  hideDiv() {
    this.isShown = ! this.isShown;
  }

}
