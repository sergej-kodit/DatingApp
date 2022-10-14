import { KeyValuePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { User } from '../_models/user.model';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};


  constructor(public accountService: AccountService) {}

  ngOnInit(): void {
 
  }

  login(form: NgForm) {
    const value = form.value;

    this.model.username = value.username;
    this.model.password = value.password;

    console.log(this.model.username + ' ' + this.model.password);

    this.accountService.login(this.model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  logout() {
    this.accountService.logout();
  }
}
