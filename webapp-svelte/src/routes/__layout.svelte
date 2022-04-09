<script>
	import Header from '$lib/header.svelte';
</script>

<Header title="SvelteKit App">
	<!-- Navigation Bar -->
	<nav slot="navigationBar" class="navbar navbar-expand-sm">
		<a class="nav-link" href="/">Home</a>
		<a class="nav-link" href="/news">Breaking News</a>
		<a class="nav-link" href="/demo">Modal</a>
		<a class="nav-link" href="/ssr">SSR</a>
	</nav>
</Header>

<div class="container-fluid">
	<div class="row">
		<main class="col-12">
			<!-- Page content -->
			<slot />
		</main>
	</div>
</div>

<footer>
	<p>Made with Svelte</p>
</footer>

<style>
	footer {
		text-align: center;
	}
</style>
