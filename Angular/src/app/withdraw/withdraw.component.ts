import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-withdraw',
  templateUrl: './withdraw.component.html',
  styles: []
})
export class WithdrawComponent implements OnInit {
 formModel = {
    balance: 0
  }

  userDetails;

  constructor(private router: Router, private service: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    debugger;
    this.service.getUserProfile(localStorage.token).subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      },
    );
  }

  onSubmit(form: NgForm) {
    debugger ; 
    this.service.updateProfile(form.value).subscribe(
      (res: any) => {
        this.router.navigateByUrl('/home');
      },
      err => {
        if (err.status == 404)
          this.toastr.error('Amount exceeded than available Amount, Please Enter correct Amount');
        else
          console.log(err);
      }
    );
  }
  
  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }

}
