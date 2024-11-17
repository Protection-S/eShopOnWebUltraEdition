<script setup>
import { RouterLink, RouterView } from 'vue-router'
import форма_edit from './components/форма_edit.vue'
import форма_create from './components/форма_create.vue'
import форма_delete from './components/форма_delete.vue'
</script>

<template>

  <div class="контейнер_страницы">
  <!--  Левая панель-->
      <div class="левая_панель">

        <div class="левая_панель_лист">

          <button class="левая_панель_текст" v-on:click="открытие_формы_create">Создать пользователя</button>
          <button class="левая_панель_текст" v-on:click="обновление_страницы_выгрузки">Вынужденное обновление</button>

        </div>

      </div>
  <!--  Конец левой панели-->

  <!--  Центр страницы с выгрузкой-->
      <div class="страница_выгрузка_форматирование">

<!--        <div class="страница_выгрузки_верхняя_панель">-->

<!--          <h1 class="страница_выгрузки_верхняя_панель_поле">Username</h1>-->
<!--          <h1 class="страница_выгрузки_верхняя_панель_поле">Email</h1>-->
<!--          <h1 class="страница_выгрузки_верхняя_панель_поле">Password</h1>-->
<!--          <h1 class="страница_выгрузки_верхняя_панель_поле">Role</h1>-->
<!--          <h1 class="страница_выгрузки_верхняя_панель_поле">Взаимодействие</h1>-->

<!--        </div>-->

        <div class="страница_выгрузки_деление_на_столбы" >

          <div class="страница_выгрузки_столб" >
            <h1 class="страница_выгрузки_верхняя_панель_поле">Username</h1>
            <div class="страница_выгрузки_данные" v-for="выгрузка_пользователей in массив_пользователей" :key="выгрузка_пользователей.userId"> <!--   v-for="выгрузка_пользователей in массив_пользователей"-->
              <h1>{{выгрузка_пользователей.userName}}</h1>
            </div>
          </div>

          <div class="страница_выгрузки_столб">
            <h1 class="страница_выгрузки_верхняя_панель_поле">Email</h1>
            <div class="страница_выгрузки_данные" v-for="выгрузка_пользователей in массив_пользователей" :key="выгрузка_пользователей.userId"> <!--   v-for="выгрузка_пользователей in массив_пользователей"-->
              <h1>{{выгрузка_пользователей.email}}</h1>
            </div>
          </div>

          <div class="страница_выгрузки_столб">
            <h1 class="страница_выгрузки_верхняя_панель_поле">Password</h1>
            <div class="страница_выгрузки_данные" v-for="выгрузка_пользователей in массив_пользователей" :key="выгрузка_пользователей.userId"> <!--   v-for="выгрузка_пользователей in массив_пользователей" -->
              <h1>{{выгрузка_пользователей.passwordHash}}</h1>
            </div>
          </div>

          <div class="страница_выгрузки_столб">
            <h1 class="страница_выгрузки_верхняя_панель_поле" >Role</h1>
            <div class="страница_выгрузки_данные" v-for="выгрузка_пользователей in массив_пользователей" :key="выгрузка_пользователей.userId"> <!--   v-for="выгрузка_пользователей in массив_пользователей"-->
              <h1>{{выгрузка_пользователей.role !== null ? выгрузка_пользователей.role : "Нет роли"}}</h1>
            </div>
          </div>

          <div class="страница_выгрузки_столб">
            <h1 class="страница_выгрузки_верхняя_панель_поле">Buttons</h1>
            <div class="страница_выгрузки_данные" v-for="выгрузка_пользователей in массив_пользователей" :key="выгрузка_пользователей.userId"> <!--   v-for="выгрузка_пользователей in массив_пользователей" -->
              <button class="страница_выгрузки_кнопка" v-on:click="открытие_формы_edit(выгрузка_пользователей.userId)">Edit</button>
              <button class="страница_выгрузки_кнопка" v-on:click="открытие_формы_delete(выгрузка_пользователей.userId)">Delete</button>
            </div>
          </div>


        </div>

<!--        <div class="страница_выгрузки_лист"  v-for="выгрузка_пользователей in массив_пользователей">-->

<!--          <div class="страница_выгрузки_данные"> &lt;!&ndash;   v-for="выгрузка_пользователей in массив_пользователей" :key="выгрузка_пользователей.userId"&ndash;&gt;-->
<!--            <h1>{{выгрузка_пользователей.userName}}</h1>-->
<!--          </div>-->
<!--          <div class="страница_выгрузки_данные">-->
<!--            <h1>{{выгрузка_пользователей.email}}</h1>-->
<!--          </div>-->
<!--          <div class="страница_выгрузки_данные">-->
<!--            <h1>{{выгрузка_пользователей.passwordHash}}</h1>-->
<!--          </div>-->
<!--          <div class="страница_выгрузки_данные">-->
<!--            <h1>{{выгрузка_пользователей.role}}</h1>-->
<!--          </div>-->
<!--          <div class="страница_выгрузки_данные">-->
<!--            <h1>{{выгрузка_пользователей.role}}</h1>-->
<!--          </div>-->

<!--        </div>-->

      </div>

  <!--  Конец центра страницы с выгрузкой-->
  </div>
  <div :style="стиль_формы_edit" v-on:click="закрытие_формы_edit">

    <component :is="форма_edit" v-if="текущий_userId" :userId="текущий_userId" v-on:close="закрытие_формы_edit" v-on:click.stop v-on:dblclick.stop/>

  </div>

  <div :style="стиль_формы_create" v-on:click="закрытие_формы_create">

    <component :is="форма_create" v-on:close="закрытие_формы_create" v-on:click.stop v-on:dblclick.stop/>

  </div>

  <div :style="стиль_формы_delete" v-on:click="закрытие_формы_delete">

    <component :is="форма_delete" v-if="текущий_userId" :userId="текущий_userId" v-on:close="закрытие_формы_delete" v-on:click.stop v-on:dblclick.stop/>

  </div>

</template>


<script>

import axios from 'axios'

export default {
  data() {
    return {
      массив_пользователей: [],
      стиль_формы_edit:{display: "none"},
      стиль_формы_create:{display: "none"},
      стиль_формы_delete:{display: "none"},
      статус_формы_edit: "закрыто",
      статус_формы_create: "закрыто",
      статус_формы_delete: "закрыто",
      текущий_userId: null,
    }
  },
  mounted() {
    axios
      .get('https://localhost:5099/api/User')
      .then((response) => {

        this.массив_пользователей = response.data
        console.log(response.data);
      })
  },
  methods:{
    обновление_страницы_выгрузки(){
      axios
        .get('https://localhost:5099/api/User')
        .then((response) => {

          this.массив_пользователей = response.data
          console.log(response.data);
        })
    },


    открытие_формы_edit(userId){
      this.текущий_userId = userId;
      this.стиль_формы_edit = {
        position: 'fixed',
        left: '0',
        top: '0',
        width: '100%',
        height: '100%',
        backgroundColor: 'rgba(0,0,0,0.55)',
        zIndex: '15',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center'
      };
      this.статус_формы_edit = "открыто";

    },

    открытие_формы_create(){
      this.стиль_формы_create = {
        position: 'fixed',
        left: '0',
        top: '0',
        width: '100%',
        height: '100%',
        backgroundColor: 'rgba(0,0,0,0.55)',
        zIndex: '15',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center'
      };
      this.статус_формы_create = "открыто";

    },

    открытие_формы_delete(userId){
      this.текущий_userId = userId;
      this.стиль_формы_delete = {
        position: 'fixed',
        left: '0',
        top: '0',
        width: '100%',
        height: '100%',
        backgroundColor: 'rgba(0,0,0,0.55)',
        zIndex: '15',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center'
      };
      this.статус_формы_delete = "открыто";
    },

    закрытие_формы_edit(){
      this.стиль_формы_edit = { display: "none" };
      this.статус_формы_edit = null;
      this.текущий_userId = null;
      this.обновление_страницы_выгрузки()

    },
    закрытие_формы_create(){
      this.стиль_формы_create = { display: "none" };
      this.статус_формы_create = null;
      this.обновление_страницы_выгрузки()

    },
    закрытие_формы_delete(){
      this.стиль_формы_delete = { display: "none" };
      this.статус_формы_delete = null;
      this.текущий_userId = null;
      this.обновление_страницы_выгрузки()

    },

  }
}

</script>

