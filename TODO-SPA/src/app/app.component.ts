import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  addTodoInput: string;

  apiUrl = 'http://localhost:5000/api/todo'

  todos: any[];

  constructor(private http: HttpClient) {
    this.todos = [];
  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.http.get<any>(this.apiUrl)
      .subscribe(
        data => {
          this.todos = data;
        }
      );
  }

  addTodo(): void {
    const body = {
      todoItem: this.addTodoInput
    }

    if (body.todoItem === '') {
      return
    }

    this.http.post<any>(this.apiUrl, body)
      .subscribe(
        data => {
          this.todos.push(data);
          this.addTodoInput = '';
        }
      );
  }

  updateTodo(todo: any): void {
    this.http.put<any>(`${this.apiUrl}/${todo.id}`, null)
      .subscribe(
        data => {
          todo = data;
          console.log(todo);
          this.todos = this.todos.map(t => t.id == todo.id ? todo : t);
        }
      )
  }

  deleteTodo(todo: any): void {
    this.http.delete<any>(`${this.apiUrl}/${todo.id}`)
      .subscribe(
        data => {
          this.todos = this.todos.filter(t => t.id != todo.id);
        }
      )
  }

}
