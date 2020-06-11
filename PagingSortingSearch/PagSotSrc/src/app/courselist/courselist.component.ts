import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { FormControl } from '@angular/forms';
import {Observable} from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import {Sort} from '@angular/material/sort';
import { Pipe, PipeTransform } from '@angular/core';
@Component({
  selector: 'app-courselist',
  templateUrl: './courselist.component.html',
  styleUrls: ['./courselist.component.css']
})

export class CourselistComponent implements OnInit {
  public courseList = [];
  public myControl = new FormControl();
  filteredData: Observable<any[]>;
  public oldData: any;
  public pageSize = 5;
  public initial = 0;
  constructor(public course: CourseService) { }

  ngOnInit() {
    this.course.getCourseDetails().subscribe((res: any) => {
      this.oldData = res;
      this.courseList = this.oldData.slice(this.initial, this.pageSize);
    });
    this.course.getCovidDetails().subscribe();
    this.filteredData = this.myControl.valueChanges.pipe(startWith(''), map(state => state ? 
    this._filteredState(state) : ''));

    this.myControl.valueChanges.subscribe(value => {
    this.courseList = value ? this.oldData.slice(this.initial, this.pageSize).filter(obj =>
       obj.courseName.toLowerCase().indexOf(value.toLowerCase()) === 0) : this.oldData.slice(this.initial, this.pageSize);
  });
  }
  private _filteredState(value: string): any {
    return this.courseList.filter(obj => obj.courseName.toLowerCase().indexOf(value.toLowerCase()) === 0);
  }
  public sortData(sort: Sort) {
    if (!sort.active) {
        this.courseList = this.oldData.slice(this.initial, this.pageSize);
        return;
    }
    this.courseList  = [...this.courseList].sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      return compare(a.courseName.toLowerCase(), b.courseName.toLowerCase(), isAsc);
    });
  }
  public setData(event: any) {
    this.initial = event.pageIndex * event.pageSize;
    this.pageSize = event.previousPageIndex < event.pageIndex ? this.pageSize + event.pageSize :
    this.pageSize - event.pageSize;
    this.courseList = this.oldData.slice(this.initial, this.pageSize);
  }
}

function compare(a: number | string, b: number | string, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
