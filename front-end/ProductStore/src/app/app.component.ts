import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @Output() userType: EventEmitter<string> = new EventEmitter<string>();
  title = 'ProductStore';
  public adminUser = "AdminUser";
  public endUser = "EndUser";
  /**
   *
   */
  constructor(private router: Router ) {
    
  }
}
