import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AuthComponent } from './auth/auth.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public dialog: MatDialog) {}
  title = 'client';


  onClickLogin() {
    const dialogRef = this.dialog.open(AuthComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
