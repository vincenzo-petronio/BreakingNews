<script>
	import { createEventDispatcher } from 'svelte';

	let isReadOnly = false;
	let dispatch = createEventDispatcher();
	export let model = {}; // default value è oggetto vuoto, ma può essere inizializzata dal chiamante

	const onSaveDispatchButtonClickListener = () => {
		dispatch('savedModel', model);
	};
</script>

<div class="modal fade" id="id_modal" tabindex="-1" role="dialog">
	<div class="modal-dialog" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<h5 class="modal-title">Modal title</h5>
				<button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
			</div>
			<div class="modal-body">
				<label for="id_name">Name</label>
				<input id="id_name" type="text" readonly={isReadOnly} bind:value={model.name} /><br />
				<label for="id_city">City</label>
				<input id="id_city" type="text" readonly={isReadOnly} bind:value={model.city} /><br />
				<label for="id_tel">Telephone</label>
				<input id="id_tel" type="number" readonly={isReadOnly} bind:value={model.telephone} /><br />
				<label for="id_sub">Subscription Date</label>
				<input id="id_sub" type="datetime" readonly={isReadOnly} value={model.subscriptionDate}/><br />
				<slot name="moreData" />
			</div>
			<div class="modal-footer">
				<button id="id_btnClose" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
				<!-- L' event click viene catturato dal chiamante, grazie al forwarding degli eventi -->
				<button id="id_btnSave" type="button" class="btn btn-primary" data-bs-dismiss="modal" on:click>Save</button>
				<button id="id_btnSaveDispatch" type="button" class="btn btn-primary" data-bs-dismiss="modal" on:click={onSaveDispatchButtonClickListener}>Save and Dispatch</button>
			</div>
		</div>
	</div>
</div>

<style></style>
