<template>
  <div>
    <form @submit.prevent="createUser">
      <div>
        <h1>Create User</h1>
      </div>
      <div class="form-group">
        <label for="UserName">Username</label>
        <input
          id="UserName"
          v-model="UserName"
          class="form-control"
          type="text"
        />
      </div>
      <div class="form-group">
        <label for="Email">Email</label>
        <input
          id="Email"
          v-model="Email"
          class="form-control"
          type="text"
        />
      </div>
      <div class="form-group">
        <label for="Password">Password</label>
        <input
          id="Password"
          v-model="Password"
          class="form-control"
          type="password"
        />
      </div>
      <div class="form-group">
        <label for="Role">Role</label>
        <input
          id="Role"
          v-model="Role"
          class="form-control"
          type="text"
        />
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" @click="closeForm">
          Cancel
        </button>
        <button type="submit" class="btn btn-primary">Create user</button>
      </div>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      UserName: "",
      Email: "",
      Password: "",
      Role: "",
    };
  },
  methods: {

    async createUser() {
      if (!this.UserName || !this.Password || !this.Email) {
        alert("All fields are required.");
        return;
      }

      try {
        if (this.Role === "")
        {
          this.Role = null
          await axios.post(
            `https://localhost:5099/api/User`,
            {
              UserName: this.UserName,
              Email: this.Email,
              Password: this.Password,
              Role: this.Role,
            }
          );
        }
        else{
          this.Role = "Administrators"
          await axios.post(
            `https://localhost:5099/api/User`,
            {
              UserName: this.UserName,
              Email: this.Email,
              Password: this.Password,
              Role: this.Role,
            }
          );
        }

        alert("User created successfully.");
        this.closeForm();
      } catch (error) {
        console.error("Error creating user:", error);
        alert("Failed to create user. Please try again.");
      }
    },
    closeForm() {
      this.$emit("close");
    },
  },
};
</script>
