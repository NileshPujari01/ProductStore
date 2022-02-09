import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-end-user-landing-page',
  templateUrl: './end-user-landing-page.component.html',
  styleUrls: ['./end-user-landing-page.component.scss']
})
export class EndUserLandingPageComponent implements OnInit {
  @Input() userTypeVal: string = "EndUser";
  constructor() { }

  ngOnInit(): void {
  }

}
