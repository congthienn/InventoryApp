import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import Swal, { SweetAlertIcon } from 'sweetalert2'
@Injectable({
  providedIn: 'root'
})
export class SweetalertService {

  constructor(private router:Router) { }
  public alertMini(title:string, text:string, icon: SweetAlertIcon){
    Swal.fire({
      toast: true,
      position: 'top-right',
      showConfirmButton: false,
      icon: icon,
      timerProgressBar: true,
      timer: 3000,
      title: title,
      width:400,
      text: text
    })
  }
  public alertAction(router:string, title:string){
    Swal.fire({
      title: 'Success!',
      text: 'Cập nhật dữ liệu thành công',
      icon: "success",
      confirmButtonText: 'Done'
    }).then((result) => {
      this.router.navigate([router]);
    })
  }
  public alertDelete(){
    
  }
}
