import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { delay } from 'rxjs';
import { AuthenticationService } from './authentication/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  public isUserAuthenticated!: boolean;
  
  constructor(private authService: AuthenticationService,
    private observer: BreakpointObserver) {
  }

  ngOnInit(): void {
    this.authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
  }

  ngAfterViewInit() {
    if(this.isUserAuthenticated)
    {
      this.observer
      .observe(['(max-width: 800px)'])
      .pipe(delay(1))
      .subscribe((res) => {
        if (res.matches) {
          this.sidenav.mode = 'side';
          this.sidenav.open();
        } else {
          this.sidenav.mode = 'over';
          this.sidenav.close();
        }
      });
    }
  }
}
