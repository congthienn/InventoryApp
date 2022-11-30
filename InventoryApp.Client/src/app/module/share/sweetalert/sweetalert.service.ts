import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import Swal, { SweetAlertIcon } from 'sweetalert2'
@Injectable({
  providedIn: 'root'
})
export class SweetalertService {

  constructor(private router:Router) { }
  public alertMini(title:string, text:string, icon: SweetAlertIcon, width = 400, timer = 3000){
    Swal.fire({
      toast: true,
      position: 'top-right',
      showConfirmButton: false,
      icon: icon,
      timerProgressBar: true,
      timer: timer,
      title: title,
      width: width,
      text: text
    })
  }
  public alertAction(router:string, title:string){
    Swal.fire({
      title: 'Success!',
      text: title,
      icon: "success",
      confirmButtonText: 'Done'
    }).then((result) => {
      this.router.navigate([router]);
    })
  }
  public alertDelete(){
    
  }
}
