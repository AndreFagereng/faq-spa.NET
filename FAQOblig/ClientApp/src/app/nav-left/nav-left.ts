import { Component } from '@angular/core';

@Component({
  selector: 'nav-left',
  templateUrl: './nav-left.html',
  styleUrls: ['./nav-left.css']
})

//This is the Regular NavMenu that is set for Angular 5.
export class NavMenuLeft {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
