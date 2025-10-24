<template>
    <Page>
        <ActionBar title="Liste des employés" />
        <StackLayout>
            <Label v-if="loading" text="Chargement..." />
            <Label v-if="error" :text="error" class="error" />
            <ListView v-if="employees.length" :items="employees">
                <v-template>
                    <Label :text="`${item.firstName} ${item.lastName} - ${item.title}`" />
                </v-template>
            </ListView>
        </StackLayout>
    </Page>
</template>

<script>
    export default {
        data() {
            return {
                employees: [],
                loading: false,
                error: null,
            };
        },
        methods: {
            getApiUrl() {
                // Change ici selon ton environnement
                return "http://192.168.20.1:3000/api/employees";
            },
            fetchEmployees() {
                this.loading = true;
                this.error = null;
                fetch(this.getApiUrl())
                    .then(res => {
                        if (!res.ok) throw new Error("Erreur réseau");
                        return res.json();
                    })
                    .then(data => {
                        this.employees = data;
                        this.loading = false;
                    })
                    .catch(err => {
                        this.error = err.message;
                        this.loading = false;
                    });
            },
        },
        mounted() {
            this.fetchEmployees();
        },
    };
</script>

<style scoped>
    .error {
        color: red;
    }
</style>
