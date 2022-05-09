import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentUrlService {
  public urlAddress: string = environment.urlAddress;
  public identityServer: string = environment.identityServer;
  constructor() { }
}
