import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css'],
})
export class PageComponent implements OnInit {
  src: any;
  error: any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http.get<any[]>(baseUrl + 'api/blog/4').subscribe(
      (result) => {
        try {
          this.src = result[0].posts[0].content;
        } catch (ex: any) {
          this.error = ex.message;
        }
      },
      (error) => (this.error = error)
    );
  }

  ngOnInit(): void {}
}
