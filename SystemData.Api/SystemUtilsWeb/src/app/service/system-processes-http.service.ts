import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/map';
import { environment } from '../..//environments/environment';
@Injectable()
export class SystemProcessesHttpService {

  private _webapiurl = environment.webapibase + '/api/SystemProcess';

  private headers = new Headers({'Content-Type': 'application/json'});
  constructor(private _http: Http) { }

  getSystemProcesses () {
    return this._http.get(this._webapiurl)
      .map((response: Response) => response.json());
  }

  stopProcess(id: number) {
    const options = new RequestOptions({ headers : this.headers});
    return this._http.delete(this._webapiurl + '/' + id, options);
  }
}
