import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user/user.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  errorMessage: string = "";
  addUserForm: FormGroup;
  addPasswordForm:FormGroup;

  constructor(public service: UserService, private fb: FormBuilder, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.addUserForm = this.fb.group({
    userName: [null, Validators.required],
    email: [null, Validators.email],
    firstName: [null],
    lastName: [null],
    password: [null],
    passwords:this.addPasswordForm = this.fb.group({
       Password: [null, [Validators.required, Validators.minLength(4)]],
       ConfirmPassword: [null, Validators.required]
     }, { validator: this.comparePasswords })
    });
  }

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  onSubmit() {
    this.errorMessage = "";
    const user: User = <User>{
      userName: this.addUserForm.value.userName,
      email: this.addUserForm.value.email,
      firstName: this.addUserForm.value.firstName,
      lastName: this.addUserForm.value.lastName,
      password: this.addPasswordForm.value.Password
  };

    this.service.register(user).subscribe( () => {
      this.router.navigate(["/login"]);
    })
  }
}

// onSubmit() {
//   this.errorMessage = "";
//   const user: User = <User>{
//     userName: this.addUserForm.value.userName,
//     email: this.addUserForm.value.email,
//     firstName: this.addUserForm.value.firstName,
//     lastName: this.addUserForm.value.lastName,
//     password: this.addPasswordForm.value.Password
// };

//   this.service.register(user).subscribe( 
//     (res: any) => {
//       if (res.succeeded) {
//         this.toastr.success('New user created!', 'Registration successful.');
//       } else {
//         res.errors.forEach(element => {
//           switch (element.code) {
//             case 'DuplicateUserName':
//               this.toastr.error('Username is already taken','Registration failed.');
//               break;

//             default:
//             this.toastr.error(element.description,'Registration failed.');
//               break;
//           }
//         });
//       }
//     },
//     err => {
//       console.log(err);
//     }
//     );
//   }
