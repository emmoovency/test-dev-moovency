import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import jwtDecode from 'jwt-decode';

// @ts-ignore
import ConfettiGenerator from 'confetti-js';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public blogs: Blog[] = [];
  public error: any = null;
  public baseUrl: any = null;
  public opennedBlog?: Blog;
  public step4Description?: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

    //BlogController::Get()
    //get all blogs from database
    http.get<Blog[]>(baseUrl + 'api/blog').subscribe(
      (result) => {
        this.blogs = result;
      },
      (error) => (this.error = error)
    );
  }

  public openBlog(b: Blog) {
    //BlogController::GetOne()
    //todo : load posts of the selected blog
    let url = `${this.baseUrl}api/blog/${blogId}`;

    this.http.get<Blog[]>(url).subscribe(
      (result) => {
        if (result.length == 0) {
          this.opennedBlog = { blogId: -1, url: '/not-found', posts: [] };
        } else {
          this.opennedBlog = result[0];
        }
        try {
          let blogData: any = jwtDecode(this.opennedBlog.posts[0].content);
          this.step4Description = blogData;
        } catch (e) {}
      },
      (error) => (this.error = error)
    );
  }
}

interface Blog {
  blogId: number;
  url: string;
  posts: Post[];
}

interface Post {
  postId: number;
  title: string;
  content: string;
}
