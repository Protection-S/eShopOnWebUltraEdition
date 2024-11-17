<template>
  <div>
    <form @submit.prevent="changePassword">
      <div>
        <h1>Edit User Password</h1>
      </div>
      <div class="form-group">
        <label for="current-password">Current Password</label>
        <input
          id="current-password"
          v-model="currentPassword"
          class="form-control"
          type="password"
        />
      </div>
      <div class="form-group">
        <label for="new-password">New Password</label>
        <input
          id="new-password"
          v-model="newPassword"
          class="form-control"
          type="password"
        />
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" @click="closeForm">
          Cancel
        </button>
        <button type="submit" class="btn btn-primary">Change Password</button>
      </div>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: {
    userId: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      currentPassword: "",
      newPassword: "",
    };
  },
  methods: {


    async changePassword() {
      if (!this.currentPassword || !this.newPassword) {
        alert("Both fields are required.");
        return;
      }

      try {
        alert("Password updated successfully.");
        this.closeForm();
      } catch (error) {
        console.error("Error changing password:", error);
        alert("Failed to change password. Please try again.");
      }
    },
    closeForm() {
      this.$emit("close");
    },
  },
};
</script>
