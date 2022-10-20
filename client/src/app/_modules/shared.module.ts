import { NgModule } from '@angular/core';
import { CommonModule, getNumberOfCurrencyDigits } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FileUploadModule } from 'ng2-file-upload';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    TabsModule.forRoot(),
    FileUploadModule,
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
  ],
  exports: [
    ToastrModule,
    TabsModule,
    FileUploadModule,
    BsDatepickerModule,
    PaginationModule,
  ],
})
export class SharedModule {}
