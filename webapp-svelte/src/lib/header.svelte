<script>
	export let title = 'Demo';
</script>

<header>
	<h1>{title}</h1>
	<slot name="navigationBar" />
</header>

<style>
	header {
		background-color: bisque;
		padding: 8px;
	}
</style>
