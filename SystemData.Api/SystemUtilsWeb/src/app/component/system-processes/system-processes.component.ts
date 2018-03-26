import { Component, OnInit } from '@angular/core';
import { ProcessViewModel } from '../../model/process-vm';
import { SystemProcessesHttpService } from '../../service/system-processes-http.service';
import { ToasterService } from 'angular2-toaster';

@Component({
  selector: 'app-system-processes',
  templateUrl: './system-processes.component.html',
  styleUrls: ['./system-processes.component.css']
})
export class SystemProcessesComponent implements OnInit {

  processes: ProcessViewModel[];
  totalProcesses: number;

  constructor(private _systemProcessesHttpService: SystemProcessesHttpService,
              private _toasterService: ToasterService) { }

  ngOnInit() {
    this.getAllProcess();
  }

  public stopProcess(item: ProcessViewModel) {
    this._systemProcessesHttpService.stopProcess(item.id)
      .subscribe(
        resData => this.onStopProcessSuccess(item),
        err => this.onResponseError(err, 'Stop process errors:'));
  }

  public getAllProcess() {
    this._systemProcessesHttpService.getSystemProcesses()
    .subscribe(
      resData => this.onDataGetSuccess(resData),
      err => this.onResponseError(err, 'Data receive errors:' ));
  }

  private onDataGetSuccess(data: any) {
    this.processes = data;
    this.totalProcesses = this.processes.length;
  }

  private onStopProcessSuccess(process: ProcessViewModel) {
    this._toasterService.pop('success', process.id + ' : ' + process.title, 'Process stoped');
    this.getAllProcess();
  }

  private onResponseError(err: any, msg: string) {
    console.log(err.name);
    this._toasterService.pop(
      'error',
      'System error:' + err.status + ' | ' +
      err.statusText,
      err.name + ' - message : ' + err.message);
  }
}
