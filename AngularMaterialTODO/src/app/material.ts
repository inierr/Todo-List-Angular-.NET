import { MatButtonModule, MatCheckboxModule, 
    MatInputModule, MatListModule, MatIconModule } from '@angular/material';
import { NgModule } from '@angular/core';

@NgModule({
    imports: [
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatListModule,
        MatIconModule,
    ],
    exports: [
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatListModule,
        MatIconModule
    ]
})

export class MaterialModule { }