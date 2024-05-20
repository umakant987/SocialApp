import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit{
  model: any = {};

  constructor(public accountService: AccountService) {}

  ngOnInit(){
  }

  login(){
    console.log("LOGIN", this.model); 
    this.accountService.login(this.model).subscribe({
      next: () => {
      },
      error: error => console.log("LOGIN Error", error)
    });
  }

  logout(){
    this.accountService.logout();
  }
}
