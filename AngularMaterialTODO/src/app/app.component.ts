import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  apiURL = 'http://localhost:5000/api/todo';

  addForm: FormGroup;
  addLoading = false;

  todoInput: string;

  todos: any[];

  constructor(
    private http: HttpClient
  ) { 
    this.todos = [];
    this.addForm = new FormGroup({
      addInput: new FormControl('')
    });
  }

  ngOnInit(): void {
    this.getTodo();
  }

  
  getTodo(): void {
    this.http.get<any>(this.apiURL)
      .subscribe(
        data => {
          this.todos = data;
        }
      )
  }

  addTodo(): void {
    const body = {
      todoItem: this.addForm.get('addInput').value,
    }

    if (body.todoItem === '') {
      return;
    }

    this.addLoading = true;
    this.http.post<any>(this.apiURL, body)
      .subscribe(
        data => {
          this.addLoading = false;
          this.addForm.get('addInput').setValue('');
          this.todos.push(data);
        }
      );
  }

  updateTodo(todoId: number): void {
    this.http.put(`${this.apiURL}/${todoId}`, null)
      .subscribe(
        data => {
          this.todos = this.todos.map(t => {
            if (t.id != todoId) {
              return t;
            }

            return data;
          });
        }
      );
  }

  deleteTodo(todoId: number): void {
    this.http.delete(`${this.apiURL}/${todoId}`)
      .subscribe(
        data => {
          this.todos = this.todos.filter(t => t.id != todoId);
        }
      )
  }
}
