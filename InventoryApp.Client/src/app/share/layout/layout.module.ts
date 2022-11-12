import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './sidebar/sidebar.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SidebarModule } from './sidebar/sidebar.module';
import { FooterModule } from './footer/footer.module';
import { HeaderModule } from './header/header.module';
import { PageTitleComponent } from './page-title/page-title.component';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SidebarModule,
    HeaderModule,
    FooterModule
  ],
  exports:[
    SidebarModule,
    FooterModule,
    HeaderModule,
  ]
})
export class LayoutModule { }
